        public double[][] DistanceMCalculate()
            {
                var result= db.Resource
                    .Where(p => p.ResourceTypeId == 1 && p.Latitude != null)
                    .Select(x => new double[] { x.Id, x.Latitude, x.Longitude })
                    .ToArray();
                
                return result;
            }
