    <div class="@(ToggleActive ? ToggleTransitionOnCssClassName: ToggleTransitionOffCssClassName)">
        @ChildContent;
    </div>
    
    @code {
    
    [Parameter] RenderFragment ChildContent { get; set; }
    
    [Parameter] string ToggleTransitionOnCssClassName { get; set; } = "";
    [Parameter] string ToggleTransitionOffCssClassName { get; set; } = "";
    
    [Parameter] int TransitionDurationMilliseconds { get; set; } = 200;
    
    public bool ToggleActive { get; set; }
    
    [Parameter] EventCallback<bool> TransitionEnded { get; set; }
    
    public async Task ToggleTransition()
    {
        ToggleActive = !ToggleActive;
        await Task.Delay(TransitionDurationMilliseconds);
        await TransitionEnded.InvokeAsync(ToggleActive);
    }
    
    
    }
and it's used like so from a parent page or component:
         @if (RenderThingy)
        {
            <Transition @ref="Transition" TransitionDurationMilliseconds="500" ToggleTransitionOnCssClassName="m-fadeOut" ToggleTransitionOffCssClassName="m-fadeIn" TransitionEnded="@TransitionComplete">
                <RenderThingy OnDismissed="@OnDismissed"></RenderThingy>
            </Transition>
        }
@code {
    Transition Transition { get; set; }
    bool RenderThingy {get; set;} = true;
    async Task OnDismissed()
    {
        await Transition.ToggleTransition();
    }
    private void TransitionComplete(bool toggleState)
    {
        RenderThingy = false;
    }
}
and css:
.m-fadeIn {
    visibility: visible;
    opacity: 1;
    animation: fadein 500ms;
}
@keyframes fadein {
    from {
        opacity: 0;
    }
    to {
        opacity: 1;
    }
}
.m-fadeOut {
    animation: fadeout 500ms;
}
@keyframes fadeout {
    from {
        opacity: 1;
    }
    to {
        opacity: 0;       
    }
}
