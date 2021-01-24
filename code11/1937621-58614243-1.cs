        <div>
            @using (Html.BeginForm("TestAction", "Default", FormMethod.Post))
            {
                @Html.Hidden("tester", Model.tester[0].tester)
                <button type="submit" class="btn btn-primary">
                    Submit 1
                </button>
            }
        </div>
        <div>
            @using (Html.BeginForm("TestAction", "Default", FormMethod.Post))
            {
                @Html.Hidden("tester", Model.tester[1].tester)
                <button type="submit" class="btn btn-primary">
                    Submit 2
                </button>
            }
        </div>
