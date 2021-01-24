        [Authorize("TokenAuthorize")]
        public override Task<BuyTicketsResponse> BuyTickets(BuyTicketsRequest request, ServerCallContext context)
        {
            var user = context.GetHttpContext().User;
            return Task.FromResult(new BuyTicketsResponse
            {
                Success = _ticketRepository.BuyTickets(user.Identity.Name!, request.Count)
            });
        }
