    public override void Write(Utf8JsonWriter writer, Update value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();
    
        if (value is UpdateA updateA)
        {
            writer.WriteNumber("TypeDiscriminator", (int)TypeDiscriminator.UpdateA);
            writer.WriteString("PropertyA", updateA.PropertyA);
        }
        else if (value is UpdateB updateB)
        {
            writer.WriteNumber("TypeDiscriminator", (int)TypeDiscriminator.UpdateB);
            writer.WriteString("PropertyB", updateB.PropertyB);
        }
    
        writer.WriteString("UpdatedAt", value.UpdatedAt);
    
        writer.WriteEndObject();
    }
