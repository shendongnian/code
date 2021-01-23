    @model MVCPortalViewModel.Models.SenderModel
    <p>@Html.Partial("Sender", Model)</p>
    <p>
        @{ Html.RenderAction("Receive1", "Receiver", Model); }
        @{ Html.RenderAction("Receive2", "Receiver", Model); }
    </p>
