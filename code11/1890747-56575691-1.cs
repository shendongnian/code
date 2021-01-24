    void Explode ()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        var enemies = colliders
                     .Select(x => x.GetComponent<Enemy>())
                     .OfType<Enemy>(); // Or IHealth, IDamageable, ITarget, etc if you have other things that can take damage.
        foreach (var enemy in enemies) // If empty, nothing will happen by default
        {
           enemy.TakeDamage(damage);
        }
    }
