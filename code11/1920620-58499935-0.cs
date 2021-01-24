    public static void DumpSingleDicomTag(string dicomFile, string tagNumber)
    {
        var dataset = DicomFile.Open(dicomFile).Dataset;
        var tag = Dicom.DicomTag.Parse(tagNumber);
        var result = dataset.GetString(tag);
        Console.Writeline(result);
    }
    // calling it with
    DumpSignleDicomTag(dicomFile, "0010,0010");
