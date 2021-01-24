            FlightTicketRequestDocument principalDocument;
            List<FlightTicketRequestDocument> groupDocuments;
            if (g.Any(f => f.StayEscortId == null))
            {
                principalDocument = g.FirstOrDefault(f => f.StayEscortId == null);
                groupDocuments = g.Where(c => c.StayEscortId != null).ToList();
            }
            else
            {
                principalDocument = g.FirstOrDefault();
                groupDocuments = g.Where(c => c.StayEscortId != null).OrderBy(f => f.FullName).Skip(1).ToList();
            }
            return new FlightTicketRequestDocumentGroup 
            { 
                GroupId = g.Key, 
                PrincipalDocument = principalDocument,
                GroupDocuments = groupDocuments 
            };
        }) 
        .ToList();
