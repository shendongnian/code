    return phases.OfType<ServicePhase>()
    .Where(p => 
    {
      bool tmpResult = p.Service.Code == par.Service.Code;
      if(tmpResult && p is ParTypePhase)
      {
          tmpResult = (p as ParTypePhase).ParType.Code == par.Type.Code;
      }
      return tmpResult;
    }).Cast<ParPhase>()
