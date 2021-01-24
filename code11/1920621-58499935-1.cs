    using System.Linq;
    public static void DumpSingleDicomTag(string dicomFile, string tagName)
    {
        var dataset = DicomFile.Open(dicomFile).Dataset;
        var entry = Dicom.DicomDictionary.Default.FirstOrDefault(t => t.Keyword == tagName);
        var result = dataset.GetString(entry.Tag);
        Console.Writeline(result);
    }
    // calling it with
    DumpSignleDicomTag(dicomFile, "PatientName");
