    private IEnumerator SwordCooldown()
    {
        canSwordGetActivated = false;
        IsSwordActivated = false;
        _meshRenderer.material = defaultSword;
        
        var timePassed = 0f;
        while(timePassed < cooldownTime)
        {
            var cooldownProgress = timePassed / cooldownTime;
            // do something with the cooldownProgress value 0-1
            timePassed += Mathf.Min(Time.deltaTime, cooldownTime - timePassed);
            yield return null;
        }
        canSwordGetActivated = true;
    }
