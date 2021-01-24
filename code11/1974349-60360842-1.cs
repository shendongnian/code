            while (matStems.Any())
            {
                var stem = MaterialStems.Dequeue();
                item.WriteStem(stem.Item1);
                var response = item.GetResponses().ElementAtOrDefault(stem.Item2);
                if(response != null) item.WriteResponse(response);
            }
