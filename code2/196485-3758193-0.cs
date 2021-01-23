    object missing = Type.Missing;
    foreach (Microsoft.Office.Interop.Word.Section section in doc.Sections) {
        if (/* some criteria */) {
            section.Range.Delete(ref missing, ref missing);
            break;
        }
    }
