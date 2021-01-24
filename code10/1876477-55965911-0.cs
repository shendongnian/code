    // Names changed to be conventional C#
    public override async Task<ReservationResponse> SaveReservation(
        global::Res.Protocol.ReservationRequest request, ServerCallContext context)
    {
        // some code for saving my reservation in repository database
        ReservationResponse response = new Res.Protocol.ReservationResponse
        {
            Type = ReservationResponse.Types.Type.Savereservation,
            Journey = GetProtoJourney(journey)
        };
        await NotifyObserversAsync(response);
        // Note: no Task.FromResult, as you're in an async method. The response
        // will already be wrapped in a task.
        return new ReservationResponse
        {
            Type = ReservationResponse.Types.Type.Savereservation
        };
    }
    public async Task NotifyObserversAsync(Res.Protocol.ReservationResponse response)
    {
        foreach (var ob in responseStreams)
        {
            await ob.WriteAsync(response);
        }
    }
