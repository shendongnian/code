    public class Bullet : MonoBehaviour {
    
        public BulletInfo BulletInfo { get; private set; }
    
        private void Update() {
            // Fly, etc.
        }
    
        public void InitalizeBullet(BulletInfo bulletInfo) {
            BulletInfo = bulletInfo;
        }
    
        // ...
    
        public void DisposeBullet() {
            BulletUndoManager.Instance.AddDeletedBulletInfo(BulletInfo, transform.position);
    
            Destroy(gameObject);
        }
    }
