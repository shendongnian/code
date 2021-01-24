            Entity instance = shapeFactory.GetEntityRandom();
            entityManager.SetComponentData<Translation>(instance, new Translation { Value = SpawnZoneOfLevel.SpawnPoint });
            entityManager.SetComponentData<Rotation>(instance, new Rotation { Value = Random.rotation });
            entityManager.SetComponentData<Scale>(instance, new Scale { Value = Random.Range(0.1f, 1f) });
            (movable ? (Action<Entity>)SetEntityMovement : RemoveMovementComponent<PersistantObjectMovement>)(instance);
            (rotatable ? (Action<Entity>)SetEntityRotation : RemoveMovementComponent<PersistantObjectRotation>)(instance);
