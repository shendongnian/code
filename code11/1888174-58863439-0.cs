CSharp
using Mono.Cecil;
using Mono.Cecil.Cil;
using Mono.Cecil.Rocks;
using System; 
using System.Linq;
using BindingFlags = System.Reflection.BindingFlags;
using Cecilifier.Runtime;
               
public class SnippetRunner
{
	public static void Main(string[] args)
	{
		var assembly = AssemblyDefinition.CreateAssembly(new AssemblyNameDefinition("name", Version.Parse("1.0.0.0")), "moduleName", ModuleKind.Dll);
		var t1 = new TypeDefinition("", "Foo", TypeAttributes.AnsiClass | TypeAttributes.BeforeFieldInit | TypeAttributes.NotPublic, assembly.MainModule.TypeSystem.Object);
		assembly.MainModule.Types.Add(t1);
		t1.BaseType = assembly.MainModule.TypeSystem.Object;
		var Foo_ctor_ = new MethodDefinition(".ctor", MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.RTSpecialName | MethodAttributes.SpecialName, assembly.MainModule.TypeSystem.Void);
		t1.Methods.Add(Foo_ctor_);
		var il1 = Foo_ctor_.Body.GetILProcessor();
		var Ldarg_02 = il1.Create(OpCodes.Ldarg_0);
		il1.Append(Ldarg_02);
		var Call3 = il1.Create(OpCodes.Call, assembly.MainModule.ImportReference(TypeHelpers.DefaultCtorFor(t1.BaseType)));
		il1.Append(Call3);
		var Ret4 = il1.Create(OpCodes.Ret);
		il1.Append(Ret4);
		
		var Foo_F_ = new MethodDefinition("F", MethodAttributes.Private | MethodAttributes.HideBySig, assembly.MainModule.TypeSystem.Void);
		t1.Methods.Add(Foo_F_);
		var il_Foo_F_ = Foo_F_.Body.GetILProcessor();
		var lv_dictionary5 = new VariableDefinition(assembly.MainModule.ImportReference(typeof(System.Collections.Generic.Dictionary<,>)).MakeGenericInstanceType(assembly.MainModule.TypeSystem.String,assembly.MainModule.TypeSystem.String));
		Foo_F_.Body.Variables.Add(lv_dictionary5);
		var Newobj6 = il_Foo_F_.Create(OpCodes.Newobj, assembly.MainModule.ImportReference(TypeHelpers.ResolveMethod("System.Private.CoreLib", "System.Collections.Generic.Dictionary`2", ".ctor",System.Reflection.BindingFlags.Default|System.Reflection.BindingFlags.Instance|System.Reflection.BindingFlags.Public,"System.String,System.String")));
		il_Foo_F_.Append(Newobj6);
		var Stloc7 = il_Foo_F_.Create(OpCodes.Stloc, lv_dictionary5);
		il_Foo_F_.Append(Stloc7);
		
// dictionary.Add("first", "1");
		var Ldloc8 = il_Foo_F_.Create(OpCodes.Ldloc, lv_dictionary5);
		il_Foo_F_.Append(Ldloc8);
		var Callvirt9 = il_Foo_F_.Create(OpCodes.Callvirt, assembly.MainModule.ImportReference(TypeHelpers.ResolveMethod("System.Private.CoreLib", "System.Collections.Generic.Dictionary`2", "Add",System.Reflection.BindingFlags.Default|System.Reflection.BindingFlags.Instance|System.Reflection.BindingFlags.Public,"System.String,System.String", "System.String", "System.String")));
		var Ldstr10 = il_Foo_F_.Create(OpCodes.Ldstr, "first");
		il_Foo_F_.Append(Ldstr10);
		var Ldstr11 = il_Foo_F_.Create(OpCodes.Ldstr, "1");
		il_Foo_F_.Append(Ldstr11);
		il_Foo_F_.Append(Callvirt9);
		
// dictionary.Add("second", "2");
		var Ldloc12 = il_Foo_F_.Create(OpCodes.Ldloc, lv_dictionary5);
		il_Foo_F_.Append(Ldloc12);
		var Callvirt13 = il_Foo_F_.Create(OpCodes.Callvirt, assembly.MainModule.ImportReference(TypeHelpers.ResolveMethod("System.Private.CoreLib", "System.Collections.Generic.Dictionary`2", "Add",System.Reflection.BindingFlags.Default|System.Reflection.BindingFlags.Instance|System.Reflection.BindingFlags.Public,"System.String,System.String", "System.String", "System.String")));
		var Ldstr14 = il_Foo_F_.Create(OpCodes.Ldstr, "second");
		il_Foo_F_.Append(Ldstr14);
		var Ldstr15 = il_Foo_F_.Create(OpCodes.Ldstr, "2");
		il_Foo_F_.Append(Ldstr15);
		il_Foo_F_.Append(Callvirt13);
		var Ret16 = il_Foo_F_.Create(OpCodes.Ret);
		il_Foo_F_.Append(Ret16);
		assembly.Write(args[0]);
	}
}
