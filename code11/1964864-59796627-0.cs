	private void doDamage(bool isGrabbed, int damage)
	{
		if (isGrabbed)
		{
			if (other.gameObject.CompareTag("PlayerBullet") && gameObject.CompareTag("Enemy1")) //Player to Enemy fire
			{
				enemy1.enemyHealth -= damage;
				Destroy(other.gameObject);
			}
			else if (other.gameObject.CompareTag("Enemy1Bullet") && gameObject.CompareTag("Player")) //Enemy to player fire
			{
				player.playerHealth -= damage;
				Destroy(other.gameObject);
			}
		}
			
	}
	private void OnTriggerEnter(Collider other)
	{
		doDamage(gunController.isGrabbed, gunController.gunDamage);
		doDamage(shotgunController.isGrabbed, shotgunController.gunDamage);
		doDamage(uziController.isGrabbed,uziController.gunDamage);
	}
