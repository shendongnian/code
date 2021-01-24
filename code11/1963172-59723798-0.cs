public static string GetDllSignature(string dllFilePath)
{
    var peFile = new PEFile.PEFile(dllFilePath);
    peFile.GetPdbSignature(out string pdbName, out Guid pdbGuid, out int pdbAge);
    return $"{pdbGuid.ToString("N")}ffffff";
}
