            object state = null; // your object
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formatter = 
                new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter(
                    null, 
                    new System.Runtime.Serialization.StreamingContext(
                        System.Runtime.Serialization.StreamingContextStates.All, 
                        state)); // pass it in
