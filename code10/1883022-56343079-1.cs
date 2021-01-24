          static void GenMethodInvocationR<TTarget>(MethodInfo method) {
            //this version winxalex generates more optimized code
            //Generated
            //            public static object MethodCallerR(ref object ptr, object[] array)
            //            {
            //                float num = (float)array[0];
            //                float num2 = (float)array[1];
            //                float num3 = (float)array[2];
            //                Vector3 vector = (Vector3)ptr;
            //                vector.Set(num, num2, num3);
            //                ptr = vector;
            //                return null;
            //            }
            //
            var weaklyTyped = typeof(TTarget) == typeof(object);
            var targetType = weaklyTyped ? method.DeclaringType : typeof(TTarget);
            var isNotStatic = !method.IsStatic;
            LocalBuilder targetLocal = null;
            // push arguments in order to call method
            var prams = method.GetParameters();
            var imax = prams.Length;
            for (int i = 0; i < imax; i++) {
                emit.ldarg1()        // stack<= paramsValuesArray[] //push array
                .ldc_i4(i)        // stack<= index push(index)
                .ldelem_ref();    // stack[top]<=paramsValuesArray[i]
                var param = prams[i];
                var dataType = param.ParameterType;
                if (dataType.IsByRef)
                    dataType = dataType.GetElementType();
                emit.unbox_any(dataType);
                emit.declocal(dataType);
                emit.stloc(i);
            }
            if (isNotStatic)
            {
                emit.ldarg0();  //stack[top]=target;
                emit.ldind_ref();//stack[top]=ref target;
                if (weaklyTyped)
                    emit.unbox_any(targetType); //stack[top]=(TargetType)target;
                targetLocal = emit.declocal(targetType); //TargetType tmpTarget; list[0]=tmpTarget;
                emit.stloc(targetLocal)     //list[0]=stack.pop();
                .ifclass_ldloc_else_ldloca(targetLocal, targetType);
            }
            //load parms from local 'list' to evaluation 'steak'
            for (int i = 0; i < imax; i++) {
                var param = prams[i];
                emit.ifbyref_ldloca_else_ldloc(i, param.ParameterType);
            }
            // perform the correct call (pushes the result)
            emit.callorvirt(method);
            if (isNotStatic && targetType.IsValueType) {
                emit.ldarg0().ldloc(targetLocal).box(targetType).stind_ref();
            }
            //check of ref and out params and
            for (int i = 0; i < prams.Length; i++) {
                var paramType = prams[i].ParameterType;
                if (paramType.IsByRef)
                {
                    var byRefType = paramType.GetElementType();
                    emit.ldarg1() // stack<= paramsValuesArray[]
                    .ldc_i4(i) // stack<= i //push(index)
                    .ldloc(i); // stack<= list[i] //push local list element at 'i' on steak
                    if (byRefType.IsValueType)
                        emit.box(byRefType);   // if ex. stack[top] =(object)stack[top]
                    emit.stelem_ref(); //  // paramsValuesArray[i]= pop(stack[top]);
                }
            }
            if (method.ReturnType == typeof(void))
                emit.ldnull();
            else if (weaklyTyped)
                emit.ifvaluetype_box(method.ReturnType);
            emit.ret();
            //vexe orignial modified by winxalex to use reference of object (ref obj) and to return value to reference
            //GENERATES
            //            public static object MethodCallerR(ref object ptr, object[] array)
            //            {
            //                Vector3 vector = (Vector3)ptr;
            //                float num = (float)array[0];
            //                float arg_56_1 = num;
            //                float num2 = (float)array[1];
            //                float arg_56_2 = num2;
            //                float num3 = (float)array[2];
            //                vector.Set(arg_56_1, arg_56_2, num3);
            //                ptr = vector;
            //                return null;
            //            }
            //            var weaklyTyped = typeof(TTarget) == typeof(object);
            //            var targetType = weaklyTyped ? method.DeclaringType : typeof(TTarget);
            //            // push target if not static (instance-method. in that case first arg is always 'this')
            //            if (!method.IsStatic)
            //            {
            //
            //                emit.declocal(targetType); //TargetType tmpTarget; list[0]=tmpTarget;
            //                emit.ldarg0();  //stack[0]=target;
            //                emit.ldind_ref();//stack[top]=ref target;
            //                if (weaklyTyped)
            //                    emit.unbox_any(targetType); //stack[0]=(TargetType)target;
            //                emit.stloc0()     //list[0]=stack.pop();
            //                .ifclass_ldloc_else_ldloca(0, targetType);
            //                // if (type.IsValueType) stack[0]=list[0].address, else stack[0]=list[0];
            //                // if (type.IsValueType) emit.ldloca(idx); else emit.ldloc(idx); return this;
            //            }
            //
            //            // if method wasn't static that means we declared a temp local to load the target
            //            // that means our local variables index for the arguments start from 1
            //            int localVarStart = method.IsStatic ? 0 : 1;
            //
            //            // push arguments in order to call method
            //            var prams = method.GetParameters();
            //            for (int i = 0, imax = prams.Length; i < imax; i++) {
            //                emit.ldarg1()        // stack<= paramsValuesArray //push array
            //                .ldc_i4(i)        // stack<= index push index
            //                .ldelem_ref();    // pop array, index and push array[index]
            //
            //                var param = prams[i];
            //                var dataType = param.ParameterType;
            //
            //                if (dataType.IsByRef)
            //                    dataType = dataType.GetElementType();
            //
            //                var tmp = emit.declocal(dataType);
            //                emit.unbox_any(dataType)
            //                .stloc(tmp)
            //                .ifbyref_ldloca_else_ldloc(tmp, param.ParameterType);
            //
            ////v2
            //
            //
            ////                emit.unbox_any(dataType);
            ////
            ////                emit.declocal(dataType);
            ////                emit.stloc(i+localVarStart)
            ////                .ifbyref_ldloca_else_ldloc(i+localVarStart, param.ParameterType);
            //
            //
            //            }
            //
            //            // perform the correct call (pushes the result)
            //            emit.callorvirt(method);
            //
            //
            //            if (!method.IsStatic && targetType.IsValueType)
            //                emit.ldarg0().ldloc0().box(targetType).stind_ref();
            //
            //
            //            for (int i = 0; i < prams.Length; i++) {
            //                var paramType = prams[i].ParameterType;
            //                if (paramType.IsByRef)
            //                {
            //                    var byRefType = paramType.GetElementType();
            //                    emit.ldarg1() // stack<= params[]
            //                    .ldc_i4(i) // stack<= i
            //                    .ldloc(i + localVarStart); // stack<= list[i+localVarStart]
            //                    if (byRefType.IsValueType)
            //                        emit.box(byRefType);   // if ex. stack =(object)stack[top]
            //                    emit.stelem_ref(); //  // stack:paramsValuesArray[i]= list[i+localVarStart];
            //                }
            //            }
            //
            //            if (method.ReturnType == typeof(void))
            //                emit.ldnull();
            //            else if (weaklyTyped)
            //                emit.ifvaluetype_box(method.ReturnType);
            //
            //            emit.ret();
        }
