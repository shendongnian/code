            Edge<int> edge = GetEdge(1);
            DirectedEdge<int> directed_edge = edge as DirectedEdge<int>;
            if (directed_edge != null)
            {
                // Use directed_edge
            } else {
                UnidirectedEdge<int> uni_edge = edge as UnidirectedEdge<int>;
                if (uni_edge != null)
                {
                    // Use uni_edge
                }
            }
