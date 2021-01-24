	private void doDamage(Controller controller)
	{
		if (controller.isGrabbed)
		{
			if (other.gameObject.CompareTag("PlayerBullet") && gameObject.CompareTag("Enemy1")) //Player to Enemy fire
			{
				enemy1.enemyHealth -= controller.damage;
				Destroy(other.gameObject);
			}
			else if (other.gameObject.CompareTag("Enemy1Bullet") && gameObject.CompareTag("Player")) //Enemy to player fire
			{
				player.playerHealth -= controller.damage;
				Destroy(other.gameObject);
			}
		}			
	}
	private void OnTriggerEnter(Collider other)
	{
		doDamage(gunController);
		doDamage(shotgunController);
		doDamage(uziController);
    }
