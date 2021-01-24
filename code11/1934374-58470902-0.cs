...
<ContentControl x:Name="navigatedRegion"/>
...
When you need to navigate your views do it:
public void NavigateToA()
{
    var viewA = new ViewA();
    navigatedRegion.Content = viewA;
}
viewA is instance of custom user control.
