    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Web;
    using Cravens.Infrastructure.Logging;
    
    namespace TruckTrackerWeb.Code
    {
        public class TripSessions
        {
            private const string _relativeSesionFile = "~/App_Data/TripSessions.txt";
            private readonly string _sessionFile;
            private readonly ILogger _logger;
            private readonly Dictionary<Guid, TripSession> _sessions;
            private readonly TimeSpan _maxAge = new TimeSpan(1, 0, 0, 0);
    
            public TripSessions(ILogger logger, HttpContextBase httpContextBase)
            {
                _logger = logger;
    
    
                _sessionFile = httpContextBase.Server.MapPath(_relativeSesionFile);
    
                _sessions = ReadSessionFile();
            }
    
            public TripSession CreateSession(string userName, int truckId)
            {
                try
                {
                    TripSession tripSession = new TripSession
                                                  {
                                                      Id = Guid.NewGuid(),
                                                      Expiration = DateTime.Now + _maxAge,
                                                      TruckId = truckId,
                                                      UserName = userName
                                                  };
                    _sessions[tripSession.Id] = tripSession;
                    SaveSessionFile();
                    _logger.Debug("Created session for: username=" + userName + ",truckid=" + truckId);
                    return tripSession;
                }
                catch (Exception ex)
                {
                    _logger.Error("Failed to create session. ", ex);
                }
                return null;
            }
    
            public TripSession GetSession(Guid id)
            {
                if(_sessions.ContainsKey(id))
                {
                    return _sessions[id];
                }
                return null;
            }
    
            private void SaveSessionFile()
            {
                _logger.Debug("Saving trip session data to file.");
                List<string> lines = new List<string>();
                foreach (KeyValuePair<Guid, TripSession> keyValuePair in _sessions)
                {
                    TripSession tripSession = keyValuePair.Value;
                    lines.Add(tripSession.ToString());
                }
                File.WriteAllLines(_sessionFile, lines.ToArray());
            }
    
            private Dictionary<Guid, TripSession> ReadSessionFile()
            {
                _logger.Debug("******READING TRIP SESSION FILE**********");
                Dictionary<Guid, TripSession> result = new Dictionary<Guid, TripSession>();
    
                if(!File.Exists(_sessionFile))
                {
                    _logger.Debug("The session file does not exist. file=" + _sessionFile);
                    return result;
                }
    
                string[] lines = File.ReadAllLines(_sessionFile);
                foreach (string line in lines)
                {
                    TripSession tripSession = TripSession.ParseLine(line);
                    if(tripSession!=null && (DateTime.Now - tripSession.Expiration)<_maxAge)
                    {
                        result[tripSession.Id] = tripSession;
                        _logger.Debug("ADDED---->" + line);
                    }
                    else
                    {
                        _logger.Debug("EXPIRED-->" + line);
                    }
                }
                return result;
            }
        }
    }
