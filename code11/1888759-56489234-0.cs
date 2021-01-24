    @{
        List<string> elementsToRender = new List<string>(5) { "element1", "element3" };
    }
    <div id="mainContainer">
        @if (elementsToRender.Contains("element1", StringComparer.OrdinalIgnoreCase))
        {
            <div id="element1">
                @* first container *@
            </div>
        }
        @if (elementsToRender.Contains("element2", StringComparer.OrdinalIgnoreCase))
        {
            <div id="element2">
                @* second container *@
            </div>
        }
        @if (elementsToRender.Contains("element3", StringComparer.OrdinalIgnoreCase))
        {
            <div id="element3">
                @* third container *@
            </div>
        }
    </div>
