    private void SetPropertyValue(JsonProperty property, JsonReader reader, object target)
        {
          // bla.. bla.. bla..
          if (!property.Writable && !useExistingValue)
          {
            reader.Skip();
            return;
          }
