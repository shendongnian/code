    public void Serialize(XmlWriter writer)
    {
    
        foreach (Instruction task in this.Tasks)
        {
            writer.WriteStartElement(task.Tag);
    
            task.Serialize(writer);
    
            writer.WriteEndElement();
        }
    }
