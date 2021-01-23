    EventType _state = EventType.SMTrans02;
    if(_state == EventType.SMTrans02 )
    {
     _state =EventType.SMTrans01;
      Obj.StateMachine.Send((int)_state, new object[2] { Obj, _state });
    }
    else
    {
    _state = EventType.SMTrans02;
    Obj.StateMachine.Send((int)_state, new object[2] { Obj, _state });
    }
