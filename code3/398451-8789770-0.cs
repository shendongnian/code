  public delegate ActionByRef&lt;T&gt;(ref T p);
  public delegate ActionByRef&lt;T1,T2&gt;(ref T1 p1, ref T2 p2);
  public void ActOnPlayer(ActionByRef&lt;playerType&gt proc;)
  {
    proc(ref _player);
  }
  public void ActOnPlayer&lt;T&gt;(ActionByRef&lt;playerType,T&gt proc, ref T param;)
  {
    proc(ref _player, ref param);
  }
... sample usage:
  map.ActOnPlayer((ref playerType it, ref int theParam) -&gt;
    {it.x = theParam;}, someIntVariable);
