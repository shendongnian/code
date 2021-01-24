using Jint.Runtime.Environments;
using Jint.Native.Object;
using Jint.Native.Global;
//Create a new object instance and environment.
JSObjectInstance = GlobalObject.CreateGlobalObject(jintEngine);
JSEnvironment = LexicalEnvironment.NewObjectEnvironment(jintEngine, JSObjectInstance, jintEngine.GlobalEnvironment, false);
//Enter the new environment.
jintEngine.EnterExecutionContext(JSEnvironment, JSEnvironment, new Jint.Native.JsValue(false));
And when you're done with that environment, you can leave using `LeaveExecutionContext`, and rejoin the default global one like so:
jintEngine.EnterExecutionContext(jintEngine.GlobalEnvironment, jintEngine.GlobalEnvironment, jintEngine.Global);
