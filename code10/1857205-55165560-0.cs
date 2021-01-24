        using (var context = new PlutoContext())
            {
                foreach (var contextData in context.Datas)
                {
                    contextData.RemainingPackets = contextData.TotalQuantity - contextData.UsePackets;
                }
                context.SaveChanges();
            }
