        /// <summary>
        /// Gets a list of Request Lines
        /// </summary>
        /// <returns>List of order lines</returns>
        [WebMethod]
        public static List<iOrderLine> GetOrdersForApproving()
        {
            try
            {
                List<iOrderLine> Lines = new List<iOrderLine>();
                foreach (Objects.Database.OrderLine oOrderLine in Objects.Database.OrderLine.GetLinesWaitingFor(StaticStore.CurrentUser.UserID, int.MinValue))
                {
                    Lines.Add(new iOrderLine(oOrderLine));
                }
                return Lines;
            }
            catch (Exception)
            {
                throw;
            }
        }
