            var graph = new CompoundGraph<object, IEdge<object>>();
        
            try
            {
                //open the file of the graph
                var reader = XmlReader.Create(fileName);
                //create the serializer
                var serializer = new GraphMLDeserializer<object, IEdge<object>, CompoundGraph<object, IEdge<object>>>();
                //deserialize the graph
                serializer.Deserialize(reader, graph,
                                       id => id, (source, target, id) => new Edge<object>(source, target)
                    );
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            layout.Graph = graph;
            layout.UpdateLayout();
