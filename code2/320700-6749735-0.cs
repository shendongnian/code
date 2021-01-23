    var modules = m_sessions
	.SelectMany(session => session.PullHits, 
				(session, pullHits) => new { pullHits = pullHits })
	.Where(session => session.pullHits.Module == _Module && 
                      session.pullHits.Response == _response)
	.Count();
