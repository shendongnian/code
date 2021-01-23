           using (ResXResourceWriter writer = new ResXResourceWriter("TBM.Resource"))
           {
               writer.AddResource(fileExtension, bitmap);
               writer.Generate();
           }
