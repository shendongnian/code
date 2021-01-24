C#
// beginning of the class
private bool _isDrawing = false;
if (!_graphIsDrawing)
{
    _graphIsDrawing = true;
    Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background,
                                               new Action(() => this.DrawGraph(new List<List<Coordinates>> { CoordinateListA, CoordinateListB }, scalingFactors, canvasSize)));
//I need to invoke, since I am working with multiple threads here. Else it
//would be enough to just call 'this.DrawGraph(...)'
}
///////////
public void DrawGraph(List<List<Coordinates>> listOfGraphs, float[] scalingFactor, int[] canvasSize)
{
    lock (_graphDrawLock)
    {
        this._AlgorithmRuntimeViewA.DrawGraph(listOfGraphs[0], scalingFactor, canvasSize);
        this._AlgorithmRuntimeViewB.DrawGraph(listOfGraphs[1], scalingFactor, canvasSize);
        _graphIsDrawing = false;
    }
}
Here I lock it again, so not both threads draw at the same time breaking everything. At the end I set _graphIsDrawing to false again, so I can call it again. 
