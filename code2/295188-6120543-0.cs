     FileStream fs = new FileStream("Resources",FileMode.OpenOrCreate, FileAccess.Write);
                IResourceWriter writer = new ResourceWriter(fs);
                writer.AddResource("TextFile1", "SomeText");
                writer.Generate();
                writer.Close();
