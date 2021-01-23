    // describes the run schedules
    class RunSchedule {
      int RunScheduleId;         // only used by DB to uniquely identify record, never seen by user
      int RunId;
      DateTime StartTime;
    }
    // describes the runs, so repeat runs do not duplicate this information
    class Run {
      int RunId;             // only used by DB to uniquely identify record, never seen by user
      string Name;           // unique run name as known by everyone, eg. "Chicago express"
      Train Train;
      string StartLocation;
      string EndLocation;
      TimeSpan Duration;
    }
    
    // describes the train-specific information, without duplicating anything
    class Train {
      int TrainId;        // only used by DB to uniquely identify record, never seen by user
      string Name;        // unique train identifier as known by everyone
      TrainType Type;
    }
    
    // describes the train-common information, shared across trains of the same type
    class TrainType {
      int TypeId;         // only used by DB to uniquely identify record, never seen by user
      string Description;
      double WeightMetricTonnes;
      double HeightMetres;
      double SpeedKms;
    }
