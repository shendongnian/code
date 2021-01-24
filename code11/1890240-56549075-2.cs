        private Vector3 GetNewPosition()
        {
            if (_movableObject != null)
            {
                Ray ray = _cam.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray.origin, ray.direction, out RaycastHit hitInfo, 200f, _groundLayerMask, QueryTriggerInteraction.Ignore))
                {
                    return hitInfo.point + _objectSelectionOffset;
                }
            }
            return _movableObject.transform.position;
        }
