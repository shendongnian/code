            //All the work is done with this constructor
            DicomFile df = new DicomFile("fileToRead.dcm");
            foreach (DicomObject d in df.DicomObjects)
            {
                Console.WriteLine(string.Format("I have a tag id of {0}, a VR of {1}", d.Tag.Id, d.VR));          
            }
            //To access the data in a native format use .Data property
            string name = df.PATIENT_NAME.Data;
