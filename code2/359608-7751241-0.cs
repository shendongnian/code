    namespace robot.task.mapBuilding
    {
        public class lists
        {
            public lists()
            {
                _canRequestNewTask= true;
            }
            private bool _canRequestNewTask;
            private string _requestNewTask;
            private string _receivedNewTask;
            public bool CanRequestNewTask {get{return _canRequestNewTask;}set{_canRequestNewTask=value;}}
            public string RequestNewTask{get{return _requestNewTask;}set{_requestNewTask=value;}}
            public string ReceivedNewTask {get{return _receivedNewTask;}set{_receivedNewTask=value;}}
        }
    
        public class exploration
        {
            public exploration()
            {
                isExploring = false;
                initialiseAreaExploration = true;
                isInExplorationArea = -1;
            }
            private bool _isExploring;
            private bool _initialiseAreaExploration;
            private bool _isInExplorationArea;
            private lists _lists;
    
            public bool IsExploring {get{return _isExploring;} set{_isExploring = value;}}
            public bool InitialiseAreaExploration{get{return _initialiseAreaExploration;}set{_initialiseAreaExploration=value;}}
            public bool IsInExplorationArea {get{return _isInExplorationArea;}set{_isInExplorationArea=value;}}
            public lists Lists {get{return _lists;}set{_lists=value;}}
       }
    }
