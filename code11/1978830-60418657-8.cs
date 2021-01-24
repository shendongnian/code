    case TouchPhase.Moved:
        if (Physics.Raycast(raycast, out raycastHit))
        {
            if (raycastHit.collider.name == this.name)
            {
                Debug.Log("move " + " " + this.name);
                transform.position = touchPos + initialDelta + Vector3.forward * initialPosition.z;
            }
        }
        break;
