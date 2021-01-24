MessagePack.Formatters.TypelessFormatter.BindToType = typeName =>
{
	var typeWithoutAssemblyName = typeName.Split(',').FirstOrDefault();
	return Type.GetType(typeWithoutAssemblyName ?? typeName, false);
};
return MessagePackSerializer.Typeless.Deserialize(File.ReadAllBytes(inputFilePath)) as C;
