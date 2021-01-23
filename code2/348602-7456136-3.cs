    private static IQueryable<AppointmentDTO> FilterAppointmentData(IEnumerable<AppointmentDTO> data, AppointmentSearchDTO searchData)
            {
                var predicate = PredicateBuilder.True<AppointmentDTO>();
                if (searchData.Status != null)
                    predicate = predicate.And(p => p.Status.Equals(Convert.ToInt32(searchData.Status)));
                if (searchData.LastName != null)
                    predicate = predicate.And(p => p.LastName.ToLower().Contains(searchData.LastName.ToLower()));
                if (searchData.File != null)
                    predicate = predicate.And(p => p.File.ToLower().Contains(searchData.File.ToLower()));
                if (searchData.Doctor != null)
                    predicate = predicate.And(p => p.Doctor.ToLower().Contains(searchData.Doctor.ToLower()));
                return data.AsQueryable().Where(predicate);
            }
