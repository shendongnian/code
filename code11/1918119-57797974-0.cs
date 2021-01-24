    private void AdjustCamera (float aspect) {
		float _1OverAspect = 1f / aspect;
		_MainCamera.fieldOfView = 2f * Mathf.Atan (Mathf.Tan (60 * Mathf.Deg2Rad * 0.5f) * _1OverAspect) * Mathf.Rad2Deg;
		Debug.Log (_MainCamera.fieldOfView);
		_OrthgraphicCamera.orthographicSize = 5 * _1OverAspect;
	}
