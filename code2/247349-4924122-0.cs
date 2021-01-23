        public IEnumerable<HotelAvail> GetAvailability (IList<string> codes, 
                                                        DateTime startDate, 
                                                        int numNights)
        {
            return codes.AsParallel().AsOrdered().Select(code => 
                     new AvailService().GetAvailability(code, startDate, numNights))
                    .ToList();
        }
