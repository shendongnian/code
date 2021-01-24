    public class ChallengeController
    {
    	[Route("/challenge/{resumePath}/{refid}/{client_id}")]
    	public async Task<ActionResult> Challenge(string resumePath, string refid, string client_id)
    	{
    		// ...
    	}
    
    	[Route("/v2/challenge/{refid}")]
    	public async Task<ActionResult> Challenge(string refid)
    	{
    		// ...
    	}
    }
