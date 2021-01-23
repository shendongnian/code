            routes.MapRoute(
            "ContactRoute", // Route name
            "Company/{id}/Contact/{action}/{contactId}", // URL with parameters
            new { controller = "Contact", action = "Index"
            } // Parameter defaults
            );
            routes.MapRoute(
            "FacilityRoute", // Route name
            "Company/{id}/Facility/{action}/{facilityId}", // URL with parameters
            new { controller = "Facility", action = "Index"
            } // Parameter defaults
            );
