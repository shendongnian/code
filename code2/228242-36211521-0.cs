    private static string GetAnswerValue(AcroFields.Item f, int i)
    {
        var widg = f.GetWidget(i);
        if (widg == null)
            return null;
        var ap = widg.GetAsDict(PdfName.AP);
        if (ap == null)
            return null;
        //PdfName.D also seems to work
        var d = ap.GetAsDict(PdfName.N);
        if (d == null)
            return null;
        var e = d.Keys.FirstOrDefault(n => !n.Equals(PdfName.OFF));
        if (e == null)
            return null;
        return e.ToString().Substring(1);
    }
