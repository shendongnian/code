...
        [OnDeserialized]
        internal void OnDeserializedMethod(StreamingContext context)
        {
            int index;
            //Check if we have the item we care about in the array
            if ((index = Array.IndexOf(itemsElementNameField,
                                       ItemsChoiceType.Bar)) <=
                -1)
            {
                return;
            }
            var target = Items[index];
            switch (target)
            {
                //Its right so don't worry about any thing
                case BarClass _:
                    return;
                //Still a JObject.  Lets make a new one and assign it to the array index
                case JObject o:
                    Items[index] = new BarClass
                                   {
                                       /*Properties*/
                                   };
                    break;
            }
        }
...
