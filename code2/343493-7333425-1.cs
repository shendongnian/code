    <table>
    @for (int i = 0; i < Model.TitleViewModels.Count; i++) {
        @Html.EditorFor(m => Model.TitleViewModels[i])
    }
    </table>
