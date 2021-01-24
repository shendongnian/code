C#
using SharpDX.DirectWrite;
private void LoadFontFeatureTags()
{
    Factory f = new Factory(FactoryType.Isolated);
    Factory4 _factory = new Factory4(f.NativePointer);
    _factory.CreateFontCollectionFromFontSet(_factory.SystemFontSet, out FontCollection1 collection);
    List<SharpDX.DirectWrite.FontFamily> loadedFonts = new List<SharpDX.DirectWrite.FontFamily>();
    for (int i = 0; i < collection.FontFamilyCount; i++)
    {
        var family = collection.GetFontFamily(i);
        loadedFonts.Add(family);
    }
    var gabriolaFont = loadedFonts.FirstOrDefault(x => x.FamilyNames.GetString(0).Contains("Gabriola"));
    var gabriolaFirstChild = gabriolaFont.GetFont(0);
    Font3 f3 = new Font3(gabriolaFirstChild.NativePointer);
    f3.CreateFontFace(out FontFace3 face3);
    ScriptAnalysis analysis = new ScriptAnalysis();
    TextAnalyzer analyzer = new TextAnalyzer(f);
    TextAnalyzer2 analyzer2 = new TextAnalyzer2((IntPtr)analyzer);
    int maxTagCount = 32;
    FontFeatureTag[] featuresArray = new FontFeatureTag[maxTagCount];
    analyzer2.GetTypographicFeatures(face3, analysis, "es-US", maxTagCount, out int actualCount, featuresArray);
}
