    StringBuilder sb = new StringBuilder();
    Parallel.Invoke(
        () => { var s = OverviewParagraph.GenerateHTMLContent(); lock (sb) sb.Append(s); },
        () => { var s = PackageWeightParagraph.GenerateHTMLContent(); lock (sb) sb.Append(s); },
        () => { var s = BoxWeightParagraph.GenerateHTMLContent(); lock (sb) sb.Append(s); },
        () => { var s = CodeQualityParagraph.GenerateHTMLContent(); lock (sb) sb.Append(s); },
        () => { var s = CodeQualityParagraph.GenerateHTMLContent(); lock (sb) sb.Append(s); }
    );
