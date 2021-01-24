    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            StartCoroutine(CastAndReset());
        }
    }
    private IEnumrator CastAndReset()
    {
        Cast();
        yield return new WaitForSeconds(dashDuration);
        playerMovementController.ResetImpact()
    }
    public override void Cast()
    {
        playerMovementController.AddForce(Camera.main.transform.forward, dashForce);
    }
