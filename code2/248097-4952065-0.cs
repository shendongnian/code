    public foo(DicomFile dfile)
    {
       DicomAttributeCollection dac;
       dac = dfile.DataSet;
       DicomUid uid;
       bool success;
       success = dac[DicomTags.SopInstanceUid].TryGetUid(0, out uid);
       if (success)
       {
          // The attribute was present in the collection.  The variable uid
          // contains the SopInstanceUid extracted from the DICOM file
       }
    }
