int nbJumps = 0;
void Update()
{
	if (Input.GetKeyDown("space") && nbJumps < 2)
	{
		//jump here
		nbJumps++;
	}
	if (playerCollider.IsTouching(groundCollider))
	{
		nbJumps = 0;
	}
}
