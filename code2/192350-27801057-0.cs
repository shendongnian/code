    cniDicomTagList = new List<CNIDicomTag>();
    foreach (DataElement element in sq)
    {
         string tag = element.Tag.ToString();
         string description = element.VR.Tag.GetDictionaryEntry().Description;
         object[] valueArr = element.Value.ToArray();
         cniDicomTagList.Add(new CNIDicomTag(tag, description, valueArr));
    }
