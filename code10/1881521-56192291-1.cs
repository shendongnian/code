...
        [OnDeserialized]
        internal void OnDeserializedMethod(StreamingContext context)
        {
            for (int i = 0; i < itemsElementNameField.Length; i++)
            {
                switch (itemsElementNameField[i])
                {
                    case ItemsChoiceType.Bar:
                        switch (Items[i])
                        {
                            case BarClass _:
                                return;
                            case JObject o:
                                Items[i] = new BarClass
                                               {
                                                   /*properties*/
                                               };
                                break;
                        }
                        break;
                        //All the other enum items we care about.
                }
            }
        }
...
