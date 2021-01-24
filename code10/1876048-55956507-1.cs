            Signer signer = new Signer
            {
                Name = signerName,
                Email = signerEmail,
                RecipientId = "1",
                RoutingOrder = "1"
            };
            Agent agent = new Agent
            {
                Name = signerName,
                Email = signerEmail,
                RecipientId = "2",
                RoutingOrder = "2"
            };
            Signer witness = new Signer
            {
                RoleName = "Witness",
                RecipientId = "3",
                RoutingOrder = "3",
            };
            Signer[] signers = new Signer[] { signer, witness };
            Agent[] agents = new Agent[] { agent };
            Recipients recipients = new Recipients { Signers = new List<Signer>(signers), Agents = new List<Agent>(agents) };
