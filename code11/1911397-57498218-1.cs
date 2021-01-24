    void Update()
	{
		if (Input.GetKeyDown(KeyCode.G))
		{
			Debug.Log(true);
			StartCoroutine(MoveInsideTheShape(speedy));
		}
	}
	public IEnumerator MoveInsideTheShape(float speed)
	{
		speed = 1 / speed;
		float totalLenght = cam.orthographicSize * 2;
		float iterationLenght = totalLenght / speed;
		Debug.Log(cam.orthographicSize);
		yield return null;
	}
