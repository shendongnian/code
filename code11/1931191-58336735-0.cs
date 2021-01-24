    private void CheckParents(List<GameObject> objects) {
        for (int i = 0; i < objects.Count; i++) {
            for (int b = i; b < objects.Count; b++) {
                if (objects[i] == objects[b].transform.parent) {
                    // i is b's parent
                }
            }
        }
    }
