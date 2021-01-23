       /// <summary>
       /// This test program demonstrates a faster way of getting call stack depth by avoiding getting a 
       /// StackTrace object. But you can't get the calling method names this way.
       ///
       /// See http://stackoverflow.com/questions/5999177/for-c-logging-how-to-obtain-call-stack-depth-with-minimal-overhead
       /// and http://ayende.com/blog/3879/reducing-the-cost-of-getting-a-stack-trace
       ///
       /// Update, late 2017, .Net mscorlib.dll has been changed for .Net 4.5. In the code below the two 
       /// possibilities are called "old .Net" and "new .Net". The two versions can be tested by setting 
       /// the target for this project to either .Net Framework 2.0 or .Net Framework 4.5.
       /// </summary>
       class TestProgram
       {
          static void Main()
          {
             OneTimeSetup();
    
             int i = GetCallStackDepth();  // i = 10 on my test machine for old .Net, 12 for new .Net
             int j = AddOneToNesting();
             Console.WriteLine(j == i + 1 ? "Test succeeded!" : "Test failed!!!!!!!!");
             Console.ReadKey();
          }
    
    
          private delegate object DGetStackFrameHelper();
    
          private static DGetStackFrameHelper _getStackFrameHelper = null;
    
          private static FieldInfo _frameCount = null;
    
    
          private static void OneTimeSetup()
          {
             try
             {
                Type stackFrameHelperType =
                                 typeof(object).Assembly.GetType("System.Diagnostics.StackFrameHelper");
    
                // ReSharper disable once PossibleNullReferenceException
                MethodInfo getStackFramesInternal =
                   Type.GetType("System.Diagnostics.StackTrace, mscorlib").GetMethod(
                                "GetStackFramesInternal", BindingFlags.Static | BindingFlags.NonPublic);
                if (getStackFramesInternal == null)
                   return;  // Unknown mscorlib implementation
    
                DynamicMethod dynamicMethod = new DynamicMethod(
                          "GetStackFrameHelper", typeof(object), new Type[0], typeof(StackTrace), true);
    
                ILGenerator generator = dynamicMethod.GetILGenerator();
                generator.DeclareLocal(stackFrameHelperType);
    
                bool newDotNet = false;
    
                ConstructorInfo constructorInfo =
                         stackFrameHelperType.GetConstructor(new Type[] {typeof(bool), typeof(Thread)});
                if (constructorInfo != null)
                   generator.Emit(OpCodes.Ldc_I4_0);
                else
                {
                   constructorInfo = stackFrameHelperType.GetConstructor(new Type[] {typeof(Thread)});
                   if (constructorInfo == null)
                      return; // Unknown mscorlib implementation
                   newDotNet = true;
                }
    
                generator.Emit(OpCodes.Ldnull);
                generator.Emit(OpCodes.Newobj, constructorInfo);
                generator.Emit(OpCodes.Stloc_0);
                generator.Emit(OpCodes.Ldloc_0);
                generator.Emit(OpCodes.Ldc_I4_0);
    
                if (newDotNet)
                   generator.Emit(OpCodes.Ldc_I4_0);  // Extra parameter
    
                generator.Emit(OpCodes.Ldnull);
                generator.Emit(OpCodes.Call, getStackFramesInternal);
                generator.Emit(OpCodes.Ldloc_0);
                generator.Emit(OpCodes.Ret);
    
    
                _getStackFrameHelper =
                      (DGetStackFrameHelper) dynamicMethod.CreateDelegate(typeof(DGetStackFrameHelper));
    
    
                _frameCount = stackFrameHelperType.GetField("iFrameCount", 
                                                        BindingFlags.NonPublic | BindingFlags.Instance);
             }
             catch
             {}  // _frameCount remains null, indicating unknown mscorlib implementation
          }
    
    
          private static int GetCallStackDepth()
          {
             if (_frameCount == null)
                return 0;  // Unknown mscorlib implementation
             return (int)_frameCount.GetValue(_getStackFrameHelper());
          }
    
    
          private static int AddOneToNesting()
          {
             return GetCallStackDepth();
          }
       }
